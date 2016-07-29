using Microsoft.Xna.Framework.Content;

namespace Raptor.Android.Objects.Levels {
    public class E1M1 : BaseLevel {
        public override string Name() => "E1M1";

        private const string LEVELJSON = "[\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\",\"Stone\"]";

        public E1M1(ContentManager cManager) : base(cManager, LEVELJSON) { }
    }
}