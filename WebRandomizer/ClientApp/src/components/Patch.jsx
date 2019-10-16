﻿import React, { Component } from 'react';
import DropdownSelect from './primitives/DropdownSelect';
import {
    Form, Row, Col, Card, CardBody, Button, Input, Label,
    InputGroup, InputGroupAddon, InputGroupText
} from 'reactstrap';
import styled from 'styled-components';
import { saveAs } from 'file-saver';
import { inflate } from 'pako';

import { Upload } from './Upload';

import { readAsArrayBuffer, applyIps, applySeed } from '../file_handling';
import { parse_rdc } from '../file_handling/rdc';
import { saveAs } from 'file-saver';

import sprites from '../files/sprite/inventory.json';
import baseIps from '../files/zsm_191016_3.ips.gz';

// through bootstrap "$input-btn-padding-x"
const inputPaddingX = '.75rem';

const SpriteOption = styled.div`
    display: flex;
    white-space: nowrap;
    > * { flex: none; }
`;

const Z3Sprite = styled.option`
    width: 16px;
    height: 24px;
    margin-right: ${inputPaddingX};
    background-size: auto 24px;
    background-position: -${props => props.index * 16}px 0;
    background-image: url(${process.env.PUBLIC_URL}/sprites/z3.png);
`;

const SMSprite = styled(Z3Sprite)`
    background-image: url(${process.env.PUBLIC_URL}/sprites/sm.png);
`;

const JumpSprite = styled.span`
    width: 17px;
    height: 17px;
    background-size: auto 17px;
    background-image: url(${process.env.PUBLIC_URL}/sprites/jump_${props => props.which}.png);
`;

export class Patch extends Component {
    static displayName = Patch.name;

    constructor(props) {
        super(props);
        this.localForage = require('localforage');
        this.state = {
            patchState: 'upload',
            spinjumps: true,
        };
        this.sprites = {
            z3: [{ title: 'Link' }, ...sprites.z3],
            sm: [{ title: 'Samus' }, ...sprites.sm],
        };
    }

    async componentDidMount() {
        let fileData = await this.localForage.getItem("baseRomCombo");
        if (fileData != null) {
            this.setState({ patchState: 'download' });
        }
    }

    handleUploadRoms = () => {
        this.setState({ patchState: 'download' });
    }

    onZ3SpriteChange = (index) => this.onSpriteChange('z3', index)
    onSMSpriteChange = (index) => this.onSpriteChange('sm', index)

    onSpriteChange(game, index) {
        this.setState({ [`${game}_sprite`]: this.sprites[game][index] });
    }

    onSpinjumps = () => {
        this.setState({ spinjumps: !this.state.spinjumps });
    }

    handleDownloadRom = async () => {
        try {
            /* find world by clients worldId to make sure we get the right world */
            let world = null;
            for (let i = 0; i < this.props.sessionData.seed.worlds.length; i++) {
                if (this.props.sessionData.seed.worlds[i].worldId === this.props.clientData.worldId) {
                    world = this.props.sessionData.seed.worlds[i];
                }
            }

            if (world !== null) {
                let patchedData = await this.prepareRom(world.patch);
                saveAs(new Blob([patchedData]), this.props.fileName);
            }
        } catch (err) {
            console.log(err);
        }
    }

    checkDecompress(data) {
        if (data[0] === 0x1f && data[1] === 0x8b) {
            return inflate(data);
        } else {
            return data;
        }
    }

    async prepareRom(world_patch) {
        const rom_blob = await this.localForage.getItem("baseRomCombo");
        const rom = new Uint8Array(await readAsArrayBuffer(rom_blob));
        const base_patch = this.checkDecompress(new Uint8Array(await (await fetch(baseIps)).arrayBuffer()));
        world_patch = Uint8Array.from(atob(world_patch), c => c.charCodeAt(0));

        applyIps(rom, base_patch);
        await this.applySprite(rom, 'link_sprite', this.state.z3_sprite);
        await this.applySprite(rom, 'samus_sprite', this.state.sm_sprite);
        this.state.spinjumps && enableSeparateSpinjumps(rom);
        applySeed(rom, world_patch);

        return rom;
    }

    async applySprite(rom, block, sprite = {}) {
        if (sprite.path) {
            const url = `${process.env.PUBLIC_URL}/sprites/${sprite.path}`;
            const rdc = this.checkDecompress(new Uint8Array(await (await fetch(url)).arrayBuffer()));
            // Todo: do something with the author field
            const [author, blocks] = parse_rdc(rdc);
            blocks[block] && blocks[block](rom);
        }
    }

    enableSeparateSpinjumps(rom) {
        rom[0x34F500] = 0x01;
    }

    handleSubmit = (e) => e.preventDefault()

    render() {
        const uploading = this.state.patchState === 'upload';
        const spinjumps = this.state.spinjumps;

        const component = uploading ? <Upload onUpload={this.handleUploadRoms} /> :
            <Form onSubmit={this.handleSubmit}>
                <Row className="mb-3">
                    <Col md="8">
                        <InputGroup className="flex-nowrap">
                            <InputGroupAddon addonType="prepend">
                                <InputGroupText>Play as</InputGroupText>
                            </InputGroupAddon>
                            <DropdownSelect placeholder="Select Z3 sprite" initialIndex={0} onIndexChange={this.onZ3SpriteChange}>
                                {this.sprites.z3.map(({ title }, i) => <SpriteOption key={title}><Z3Sprite index={i} />{title}</SpriteOption>)}
                            </DropdownSelect>
                            <DropdownSelect placeholder="Select SM sprite" initialIndex={0} onIndexChange={this.onSMSpriteChange}>
                                {this.sprites.sm.map(({ title }, i) => <SpriteOption key={title}><SMSprite index={i} />{title}</SpriteOption>)}
                            </DropdownSelect>
                            <InputGroupAddon addonType="append">
                                <InputGroupText tag={Label} title="Enable separate space/screw jump animations">
                                    <Input type="checkbox" addon={true} checked={spinjumps} onChange={this.onSpinjumps} />{' '}
                                    <JumpSprite which="space" /> / <JumpSprite which="screw" />
                                </InputGroupText>
                            </InputGroupAddon>
                        </InputGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md="6">
                        <Button color="primary" onClick={this.handleDownloadRom}>Download ROM</Button>
                    </Col>
                </Row>
            </Form>;

        return (
            <Card>
                <CardBody>
                    {component}
                </CardBody>
            </Card>
        );
    }
}
