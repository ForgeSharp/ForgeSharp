using System;
using System.Collections.Generic;

namespace ForgeSharp.Logging
{
    public static class Logger
    {
        public static readonly Queue<LogMessage> queue = new Queue<LogMessage>();

        private static readonly List<LogMessage> lockedQueue = new List<LogMessage>();

        public static bool Locked { get; private set; }

        private static void Log(LogMessage message)
        {
            Console.WriteLine($"<{message.Time}> [{message.Source}] {message.Message}");
        }

        public static void LockUntil(Action action)
        {
            Logger.Lock();
            action();
            Logger.Release();
        }

        /// <summary>
        /// Lock the current queue
        /// </summary>
        public static bool Lock()
        {
            if (Logger.Locked)
            {
                return false;
            }

            Logger.Locked = true;
            Logger.lockedQueue.AddRange(Logger.queue);
            Logger.queue.Clear();

            return true;
        }

        /// <summary>
        /// Release the locked queue
        /// </summary>
        public static bool Release()
        {
            if (!Logger.Locked)
            {
                return false;
            }

            foreach (LogMessage message in Logger.lockedQueue)
            {
                Logger.queue.Enqueue(message);
            }

            Logger.lockedQueue.Clear();
            Logger.ProcessQueue();

            return true;
        }

        public static void ProcessQueue()
        {
            while (Logger.queue.Count > 0)
            {
                Logger.Log(Logger.queue.Dequeue());
            }
        }

        public static void Verbose(string message)
        {
            Logger.Enqueue(message);
        }

        public static void Success(string message)
        {
            Logger.Enqueue(message, LogLevel.Success);
        }

        public static void Info(string message)
        {
            Logger.Enqueue(message, LogLevel.Info);
        }

        public static void Warning(string message)
        {
            Logger.Enqueue(message, LogLevel.Warning);
        }

        public static void Error(string message)
        {
            Logger.Enqueue(message, LogLevel.Error);
        }

        public static void Fatal(string message)
        {
            Logger.Enqueue(message, LogLevel.Fatal);
        }

        public static void Debug(string message)
        {
            Logger.Enqueue(message, LogLevel.Debug);
        }

        public static void Enqueue(LogMessage message)
        {
            if (!Logger.Locked)
            {
                Logger.queue.Enqueue(message);
                Logger.ProcessQueue();
            }
            else
            {
                Logger.lockedQueue.Add(message);
            }
        }

        public static void Enqueue(string message, LogLevel level = LogLevel.Verbose)
        {
            Logger.Enqueue(Logger.CreateAnonymous(message, level));
        }

        public static LogMessage CreateAnonymous(string message, LogLevel level = LogLevel.Verbose)
        {
            return new LogMessage()
            {
                Level = level,
                Message = message
            };
        }
    }
}
