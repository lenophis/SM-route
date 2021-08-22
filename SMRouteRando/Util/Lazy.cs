using System;

namespace SMRouteRando {

    public class Lazy<T> where T : class {

        T value;
        readonly Func<T> factory;

        public Lazy(T value) => this.value = value;
        public Lazy(Func<T> factory) => this.factory = factory;

        public T Value => value ??= factory();
        public static implicit operator T(Lazy<T> lazy) => lazy.Value;

    }

}
