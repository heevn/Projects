namespace ProjectRPVS
{
    internal class SaveLoad
    {
        internal static void Save(string a, string b, string c, string d, string e, string f, bool g, bool h)
        {
            Properties.Settings.Default.save1 = a;
            Properties.Settings.Default.save2 = b;
            Properties.Settings.Default.save3 = c;
            Properties.Settings.Default.save4 = d;
            Properties.Settings.Default.savex = e;
            Properties.Settings.Default.savey = f;
            Properties.Settings.Default.ifChecked1 = g;
            Properties.Settings.Default.ifChecked2 = h;
            Properties.Settings.Default.Save();
        }
        
        internal static void Load(string a, string b, string c, string d, string e, string f, bool g, bool h)
        {
            a = Properties.Settings.Default.save1;
            b = Properties.Settings.Default.save2;
            c = Properties.Settings.Default.save3;
            d = Properties.Settings.Default.save4;
            e = Properties.Settings.Default.savex;
            f = Properties.Settings.Default.savey;
            g = Properties.Settings.Default.ifChecked1;
            h = Properties.Settings.Default.ifChecked2;
            Properties.Settings.Default.Save();
        }
    }
}
