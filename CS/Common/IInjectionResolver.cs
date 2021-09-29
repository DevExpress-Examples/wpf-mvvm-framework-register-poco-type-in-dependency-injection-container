using System;

namespace Common {
    public interface IInjectionResolver {
        object Resolve(Type type, object key, string name);
    }
}
