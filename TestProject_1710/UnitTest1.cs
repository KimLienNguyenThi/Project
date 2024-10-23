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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2000));

            IWebElement DnButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("DN")));
            Assert.IsNotNull(DnButton);
            DnButton.Click();

            IWebElement phoneNameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("phoneNumber")));
            phoneNameField.SendKeys("0466155193");
            Thread.Sleep(1000);
            IWebElement passWordField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password")));
            passWordField.SendKeys("0466155193");
            Thread.Sleep(1000);

            IWebElement login = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("DangNhap")));
            login.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://localhost:7176/User/Index"));
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);

            IWebElement close = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("buttonCloseModal")));

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
            Thread.Sleep(1000);

            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("");
            Thread.Sleep(1000);
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");
            Thread.Sleep(1000);
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
            Thread.Sleep(1000);
            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");
            Thread.Sleep(1000);
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("");
            Thread.Sleep(1000);

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
            Thread.Sleep(1000);
            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");
            Thread.Sleep(1000);

            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("sfgxfsssszdd");
            Thread.Sleep(1000);

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
            Thread.Sleep(1000);
            IWebElement phoneNameField = _driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0886498002");
            Thread.Sleep(1000);
            IWebElement passWordField = _driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");
            Thread.Sleep(1000);
            IWebElement login = _driver.FindElement(By.Name("DangNhap"));
            login.Click();

            // Kiểm tra
            Assert.AreEqual("https://localhost:7176/User/Index", _driver.Url);
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


    public class SearchTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7176/"); // Thay đổi URL nếu cần

            // Tìm nút Đăng nhập (DN)
            IWebElement DnButton = driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();
            Thread.Sleep(1000);
            // Nhập thông tin số điện thoại
            IWebElement phoneNameField = driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");
            Thread.Sleep(1000);
            // Nhập mật khẩu
            IWebElement passWordField = driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");
            Thread.Sleep(1000);
            // Nhấn nút Đăng nhập
            IWebElement login = driver.FindElement(By.Name("DangNhap"));
            login.Click();
            Thread.Sleep(1000);
            // Kiểm tra đã chuyển hướng sau khi đăng nhập thành công
            Assert.AreEqual("https://localhost:7176/User/Index", driver.Url);

            // Chờ cho nút "Đóng" modal xuất hiện và sẵn sàng để click
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement close = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("buttonCloseModal")));

            // Cuộn tới phần tử nếu cần (nếu nó nằm ngoài màn hình)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", close);

            // Nhấn vào nút "Đóng"
            close.Click();
        }
        [Test]
        public void SearchKeyword()
        {
            IWebElement ThueSachBtn = driver.FindElement(By.Name("TS"));
            Assert.IsNotNull(ThueSachBtn);
            ThueSachBtn.Click();
            Thread.Sleep(1000);
            IWebElement SearchField = driver.FindElement(By.Id("searchInput"));
            SearchField.SendKeys("Thỏ Bảy Màu Và Những Người Nghĩ Nó Là Bạn");
            Thread.Sleep(1000);
            IWebElement search = driver.FindElement(By.Name("Search"));
            search.Click();
            Thread.Sleep(1000);
            Assert.AreEqual("https://localhost:7176/BorrowBook/Index", driver.Url);
        }
        [Test]
        public void SearchKeywordNull()
        {
            IWebElement ThueSachBtn = driver.FindElement(By.Name("TS"));
            Assert.IsNotNull(ThueSachBtn);
            ThueSachBtn.Click();
            Thread.Sleep(1000);
            IWebElement SearchField = driver.FindElement(By.Id("searchInput"));
            SearchField.SendKeys(" ");
            Thread.Sleep(1000);
            IWebElement search = driver.FindElement(By.Name("Search"));
            search.Click();
            Thread.Sleep(1000);
            Assert.AreEqual("https://localhost:7176/BorrowBook/Index", driver.Url);
        }
        [TearDown]
        public async Task TearDown()
        {
            // Đợi 5 giây
            await Task.Delay(5000);

            // Đóng trình duyệt
            driver.Dispose();
        }
    }

    public class FilterTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7176/"); // Thay đổi URL nếu cần
            driver.Manage().Window.Maximize();

            // Tìm nút Đăng nhập (DN)
            IWebElement DnButton = driver.FindElement(By.Name("DN"));
            Assert.IsNotNull(DnButton);
            DnButton.Click();
            Thread.Sleep(1000);
            // Nhập thông tin số điện thoại
            IWebElement phoneNameField = driver.FindElement(By.Id("phoneNumber"));
            phoneNameField.SendKeys("0466155193");
            Thread.Sleep(1000);
            // Nhập mật khẩu
            IWebElement passWordField = driver.FindElement(By.Id("password"));
            passWordField.SendKeys("0466155193");
            Thread.Sleep(1000);
            // Nhấn nút Đăng nhập
            IWebElement login = driver.FindElement(By.Name("DangNhap"));
            login.Click();
            Thread.Sleep(1000);
            // Kiểm tra đã chuyển hướng sau khi đăng nhập thành công
            Assert.AreEqual("https://localhost:7176/User/Index", driver.Url);

            // Chờ cho nút "Đóng" modal xuất hiện và sẵn sàng để click
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement close = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("buttonCloseModal")));

            // Cuộn tới phần tử nếu cần (nếu nó nằm ngoài màn hình)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", close);

            // Nhấn vào nút "Đóng"
            close.Click();
        }

        [Test]
        public void FilterCategory()
        {
            IWebElement ThueSachBtn = driver.FindElement(By.Name("TS"));
            Assert.IsNotNull(ThueSachBtn);
            ThueSachBtn.Click();
            Thread.Sleep(1000);
            IWebElement CategoryField = driver.FindElement(By.Id("theLoaiSelect"));
            Assert.IsNotNull (CategoryField);
            CategoryField.Click();
            Thread.Sleep(1000);
            SelectElement CategorySelect = new SelectElement(CategoryField);
            CategorySelect.SelectByValue("Tiểu thuyết");
            Thread.Sleep(1000);
            IWebElement filter = driver.FindElement(By.Id("filter"));
            filter.Click();

            Assert.AreEqual("https://localhost:7176/BorrowBook/Index", driver.Url);

        }

        [Test]
        public void FilterLanguage()
        {
            IWebElement ThueSachBtn = driver.FindElement(By.Name("TS"));
            Assert.IsNotNull(ThueSachBtn);
            ThueSachBtn.Click();
            Thread.Sleep(1000);
            IWebElement LanguageField = driver.FindElement(By.Id("ngonNguSelect"));
            Assert.IsNotNull(LanguageField);
            LanguageField.Click();
            Thread.Sleep(1000);
            SelectElement CategorySelect = new SelectElement(LanguageField);
            CategorySelect.SelectByValue("Tiếng việt");
            Thread.Sleep(1000);
            IWebElement filter = driver.FindElement(By.Id("filter"));
            filter.Click();

            Assert.AreEqual("https://localhost:7176/BorrowBook/Index", driver.Url);

        }
        [Test]
        public void FilterYOF()
        {
            IWebElement ThueSachBtn = driver.FindElement(By.Name("TS"));
            Assert.IsNotNull(ThueSachBtn);
            ThueSachBtn.Click();
            Thread.Sleep(1000);
            IWebElement YOFField = driver.FindElement(By.Id("namXBSelect"));
            Assert.IsNotNull(YOFField);
            YOFField.Click();
            Thread.Sleep(1000);
            SelectElement CategorySelect = new SelectElement(YOFField);
            CategorySelect.SelectByValue("2020");
            Thread.Sleep(1000);
            IWebElement filter = driver.FindElement(By.Id("filter"));
            filter.Click();

            Assert.AreEqual("https://localhost:7176/BorrowBook/Index", driver.Url);

        }

        [TearDown]
        public async Task TearDown()
        {
            // Đợi 5 giây
            await Task.Delay(5000);

            // Đóng trình duyệt
            driver.Dispose();
        }
    }

    
}
