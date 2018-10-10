using System;
using System.Diagnostics;
using SenseNet.Diagnostics;

namespace SenseNet.ContentRepository
{
    internal class SenseNetPerformanceCounter
    {
        private readonly PerformanceCounter _counter;

        internal SenseNetPerformanceCounter(PerformanceCounter counter)
        {
            _counter = counter ?? throw new ArgumentNullException(nameof(counter));
            _counter.ReadOnly = false;

            Accessible = true;
        }

        internal bool Accessible { get; private set; }
        internal string CounterName => _counter.CounterName;

        // ============================================================================== Performance counter API

        internal bool Increment()
        {
            if (!Accessible)
                return false;

            try
            {
                _counter.Increment();
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }

            return true;
        }
        internal bool IncrementBy(long value)
        {
            if (!Accessible)
                return false;

            try
            {
                _counter.IncrementBy(value);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }

            return true;
        }
        internal bool Decrement()
        {
            if (!Accessible)
                return false;

            try
            {
                _counter.Decrement();
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }

            return true;
        }
        internal bool SetRawValue(long value)
        {
            if (!Accessible)
                return false;

            try
            {
                _counter.RawValue = value;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }

            return true;
        }

        internal bool Reset()
        {
            return SetRawValue(0);
        }

        // ============================================================================== Helper methods

        private void LogException(Exception ex)
        {
            if (!Accessible)
                return;

            lock (_counter)
            {
                if (!Accessible)
                    return;

                Accessible = false;
                SnLog.WriteException(ex);
            }
        }
    }
}
