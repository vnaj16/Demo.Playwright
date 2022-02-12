using Microsoft.Playwright;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{ Headless = false, SlowMo =50 });

var context = await browser.NewContextAsync();
var page = await context.NewPageAsync();

//Navigate to Google.com
await page.GotoAsync("https://www.google.com/");
// Search Playwright
await page.FillAsync("[aria-label=\"Buscar\"]", "Playwirght");

// Press Enter
await page.RunAndWaitForNavigationAsync(async () =>
{
    await page.PressAsync("[aria-label=\"Buscar\"]", "Enter");
});

//Click on the first search option
await page.ClickAsync("h3[contains(text(), 'Playwright: Fast and reliable end-to-end testing f'))");

// Click text-Get started
await page.ClickAsync("text=Get started");

// Take a screenshot
await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });

Console.ReadLine();