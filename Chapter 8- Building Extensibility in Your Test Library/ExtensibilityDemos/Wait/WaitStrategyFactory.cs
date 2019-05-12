namespace ExtensibilityDemos
{
    public class WaitStrategyFactory
    {
        internal WaitToExistsStrategy Exists(int? timeoutInterval = null, int? sleepinterval = null)
        {
            return new WaitToExistsStrategy(timeoutInterval, sleepinterval);
        }

        internal WaitToBeVisibleStrategy BeVisible(int? timeoutInterval = null, int? sleepinterval = null)
        {
            return new WaitToBeVisibleStrategy(timeoutInterval, sleepinterval);
        }

        internal WaitToBeClickableStrategy BeClickable(int? timeoutInterval = null, int? sleepinterval = null)
        {
            return new WaitToBeClickableStrategy(timeoutInterval, sleepinterval);
        }
    }
}
