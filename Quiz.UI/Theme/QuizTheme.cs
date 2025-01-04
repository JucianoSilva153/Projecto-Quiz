using MudBlazor;

namespace Quiz.UI.Theme;

public class QuizTheme
{
    public MudTheme Theme = new MudTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = Colors.Blue.Lighten1,
            Secondary = Colors.BlueGray.Lighten1,
            AppbarBackground = Colors.BlueGray.Lighten5,
            DrawerBackground = Colors.BlueGray.Lighten5
        },
        PaletteDark = new PaletteDark()
        {
            Primary = Colors.Blue.Darken4
        },

        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px"
        }
    };
}