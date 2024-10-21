using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace TestProject_1710

{
    [TestFixture]


    public class HomePageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://localhost:7176/"); // Thay đổi URL nếu cần
        }
        [Test]
        public void TestDN()
        {
            // Tìm nút Đăng nhập (DN)
            IWebElement DnButton = _driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

            // Nhập thông tin số điện thoại
            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");

            // Nhập mật khẩu
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");

            // Nhấn nút Đăng nhập
            IWebElement login = _driver.FindElement(By.Name("DangNhap"));
            login.Click();

            // Kiểm tra đã chuyển hướng sau khi đăng nhập thành công
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);

            // Chờ cho nút "Đóng" modal xuất hiện và sẵn sàng để click
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement close = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("buttonCloseModal")));

            // Cuộn tới phần tử nếu cần (nếu nó nằm ngoài màn hình)
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", close);

            // Nhấn vào nút "Đóng"
            close.Click();
        }

        [Test]
        public void TestDNEmptyUser()
        {
            IWebElement DnButton = _driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("");
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");

            IWebElement login = _driver.FindElement(By.Name("DangNhap"));
            login.Click();

            // Kiểm tra
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);

        }

        [Test]
        public void TestDNEmptyPassword()
        {
            IWebElement DnButton = _driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("");

            IWebElement login = _driver.FindElement(By.Name("DangNhap"));
            login.Click();

            // Kiểm tra
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);
        }
        [Test]
        public void TestDNFailedPassword()
        {
            IWebElement DnButton = _driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("sfgxfsssszdd");

            IWebElement login = _driver.FindElement(By.Name("DangNhap"));
            login.Click();

            // Kiểm tra
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);
        }
        [Test]
        public void TestDNFailedPhoneNumber()
        {
            IWebElement DnButton = _driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0886498002");
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");

            IWebElement login = _driver.FindElement(By.Name("DangNhap"));
            login.Click();

            // Kiểm tra
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);
        }

        [Test]
        public void TestDK()
        {
            IWebElement DnButton = _driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

        }

        [TearDown]
        public async Task TearDown()
        {
            // Đợi 5 giây
            await Task.Delay(5000);

            // Đóng trình duyệt
            _driver.Dispose();
        }
    }
}
