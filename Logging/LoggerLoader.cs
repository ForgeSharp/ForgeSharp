using System;

namespace ForgeSharp.Logging
{
    public class LoggerLoader
    {
        private readonly int max;

        private int current;

        public LoggerLoader(int max = 100, int start = 0)
        {
            this.max = max;
            this.current = start;
        }

        public int Increment(int amount = 1)
        {
            if (amount == 0)
            {
                throw new InvalidOperationException("Amount must not be zero");
            }
            else if (this.current + amount > this.max)
            {
                this.current = this.max;

                return this.max;
            }
            else if (this.current + amount < 0)
            {
                this.current = 0;

                return this.current;
            }

            this.current += amount;

            return this.current;
        }

        public int Decrement(uint amount = 1)
        {
            if (amount < 1)
            {
                throw new InvalidOperationException("Amount must be 1 or greater");
            }

            return this.Increment((int)(-1 * amount));
        }

        public int GetPercentage()
        {
            return (this.current / this.max) * 100;
        }

        public int GetPercentageLeft()
        {
            return 100 - this.GetPercentage();
        }

        public void Start(string prefix = "Loading")
        {
            // TODO: Finish implementing
            Logger.Lock();
            Logger.Verbose($"\n{prefix} [", true, true);

            throw new NotImplementedException();
        }
    }
}
