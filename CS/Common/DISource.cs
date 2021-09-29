using System;
using System.Windows.Markup;

namespace Common {
    public class DISource : MarkupExtension {
        public static IInjectionResolver Resolver { get; set; }

        public Type Type { get; set; }
        public object Key { get; set; }
        public string Name { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => Resolver?.Resolve(Type, Key, Name);
    }
}
