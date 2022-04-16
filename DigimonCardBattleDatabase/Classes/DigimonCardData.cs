using System.Text;

namespace DigimonCardBattleDatabase.Classes
{
    public class DigimonCardData
    {
        public string Name { get; set; }
        public string Name_jp { get; set; }
        public string Name_jp_roman { get; set; }
        public string Number { get; set; }
        public string? Level { get; set; }
        public string? Specialty { get; set; }
        public string? Hp { get; set; }
        public string? Dp { get; set; }
        public string? Pp { get; set; }
        public string? C_attack { get; set; }
        public string? C_attack_jp { get; set; }
        public string? C_attack_jp_roman { get; set; }
        public string? C_pow { get; set; }
        public string? T_attack { get; set; }
        public string? T_attack_jp { get; set; }
        public string? T_attack_jp_roman { get; set; }
        public string? T_pow { get; set; }
        public string? X_attack { get; set; }
        public string? X_attack_jp { get; set; }
        public string? X_attack_jp_roman { get; set; }
        public string? X_pow { get; set; }
        public string? X_effect { get; set; }
        public string? Support { get; set; }
        public string? Effect { get; set; }
        public int FusionMaterialPoints { get; set; }
        public int FusionMaterialCost { get; set; }

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name:" + Name);
            sb.Append("\n Number:" + Number);
            if (Specialty != null)
            {
                sb.Append("\n HP:" + Hp);
                sb.Append("\n DP:" + Dp);
                sb.Append("\n PP:" + Pp);
                sb.Append("\n Support:" + Support);

            }
            else
            {
                sb.Append("\n Effect:" + Effect);
            }
            sb.Append("\n Fusion Material points:" + FusionMaterialPoints);
            sb.Append("\n Fusion Material Cost:" + FusionMaterialCost);

            return (sb.ToString());
        }
    }
}
