namespace WinFormsThreadingDemo;

public partial class MainForm : Form
{
    private readonly ICalcService calcService;

    public MainForm(ICalcService calcService)
    {
        this.InitializeComponent();

        this.calcService = calcService;
    }

    private async void HandleSqrtButtonClick(object sender, EventArgs e)
    {
        this.sqrtButton.Enabled = false;

        try
        {
            if (double.TryParse(this.valueTextBox.Text, out double number))
            {
                double sqrt = await this.calcService.SqrtAsync(number); //.ConfigureAwait(false);

                this.valueTextBox.Text = sqrt.ToString();
            }
        }
        finally
        {
            this.sqrtButton.Enabled = true;
        }
    }
}
