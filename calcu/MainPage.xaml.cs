namespace calcu
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string operatorMath;
        Double firstNum, secondNum;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            currentState = 1;
            this.result.Text = "0";
        }

        void OnSquareRoot(object sender, EventArgs e)
        {
            if (firstNum == 0)
                return;
            firstNum = firstNum * firstNum;
            this.result.Text = firstNum.ToString();
        }

        void OnNumberSelection(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnPressed = button.Text;

            if (this.result.Text == "0" || currentState < 0)
            {
                this.result.Text = string.Empty;
                if (currentState < 0)
                    currentState *= -1;
            }

            double number;
            if (double.TryParse(btnPressed, out number))
            {
                if (currentState == 1)
                {
                    firstNum = firstNum * 10 + number; 
                    this.result.Text = firstNum.ToString();
                }
                else
                {
                    secondNum = secondNum * 10 + number; 
                    this.result.Text = firstNum.ToString() + " " + operatorMath + " " + secondNum.ToString();
                }
            }
        }


        void onOperatorSelection(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string btnPressed = button.Text;
            operatorMath = btnPressed;
            this.result.Text = firstNum.ToString() + " " + operatorMath;
        }

        void onCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Calculate.DoCalculation(firstNum, secondNum, operatorMath);

                this.result.Text = result.ToString();
                firstNum = result;
                currentState = -1;
            }
        }
    }
}
