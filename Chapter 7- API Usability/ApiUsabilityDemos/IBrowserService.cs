namespace ApiUsabilityDemos
{
    public interface IBrowserService
    {
        ////string HtmlSource { get; }
        ////string Title { get; }
        ////void Back();
        ////void Forward();
        ////void Refresh();
        ////void Maximize();
        void WaitForAjax();
        void WaitForJavaScriptAnimations();
        void WaitUntilPageLoadsCompletely();
        void Start(Browser browser);
        void Quit();
    }
}
