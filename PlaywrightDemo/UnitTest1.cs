using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDemo
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        private IBrowser _browser { get; set; }
        private IPage _page { get; set; }
        private IPlaywright _playwright { get; set; }

        //Vid 1 Excution automation Chanel
        [Test]
        public async Task Test1()
        {
            // Playwright Connection
            _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            // Browser Opening
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Devtools = true
            });
            // Page
            _page = await _browser.NewPageAsync();

            /// working AAA
            await _page.GotoAsync("https://harmash.com/");//navigate
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "HARMASH_page.jpg"
            });
            await _page.ClickAsync(".account-menu");//selector
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                            Path = "HARMASH_login.jpg"
            });

            await _page.FillAsync("input[type='text']", "nabil_djilali");
            await _page.FillAsync("input[type='password']", "Info0676124353germany*");
            await _page.ClickAsync("button[type=submit]");//selector
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "HARMASH_result.jpg"
            });
            var isexist = await _page.Locator("text='SQL'").IsVisibleAsync();
            Assert.That(isexist, Is.True);

        }

        [Test]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = Page.Locator("text=Get Started");

            // Expect an attribute "to be strictly equal" to the value.
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
    }
}
