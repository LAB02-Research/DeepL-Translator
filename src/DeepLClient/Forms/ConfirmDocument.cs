using Syncfusion.Windows.Forms;

namespace DeepLClient.Forms
{
    public partial class ConfirmDocument : MetroForm
    {
        private readonly string _chars;
        private readonly string _price;
        private readonly string _file;
        private readonly bool _isTxt;

        public ConfirmDocument(long chars, string price, string file, bool isTxt = false)
        {
            _chars = $"{chars:N0}";
            _price = price;
            _file = file;
            _isTxt = isTxt;

            InitializeComponent();
        }

        private void ConfirmDocument_Load(object sender, EventArgs e)
        {
            LblCostInfo.Text = LblCostInfo.Text.Replace("{0}", _chars);
            LblCostInfo.Text = LblCostInfo.Text.Replace("{1}", _price);
            LblCostInfo.Text = LblCostInfo.Text.Replace("{2}", _file);

            if (_isTxt) LblTxt.Visible = true;

            ActiveControl = BtnYes;
        }

        private void BtnNo_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void BtnYes_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;
    }
}