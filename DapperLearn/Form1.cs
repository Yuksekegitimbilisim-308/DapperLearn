namespace DapperLearn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductRepository repo = new();
            //var result =  repo.GetAllProducts();
            var result = repo.GetProductById2(1);
            repo.AddUser();
        }
    }
}
