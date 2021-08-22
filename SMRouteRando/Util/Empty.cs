using System;
using System.Collections.Generic;

namespace SMRouteRando.Util {

    public static class Empty<T> {

        public static IList<T> List { get; } = Array.Empty<T>();

    }

}
