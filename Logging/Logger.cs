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

        /// <summary>
        /// Lock the current queue
        /// </summary>
        public static void Lock()
        {
            Logger.Locked = true;
            Logger.lockedQueue.AddRange(Logger.queue);
            Logger.queue.Clear();
        }

        /// <summary>
        /// Release the locked queue
        /// </summary>
        public static void Release()
        {
            foreach (LogMessage message in Logger.lockedQueue)
            {
                Logger.queue.Enqueue(message);
            }

            Logger.lockedQueue.Clear();
            Logger.ProcessQueue();
        }

        public static void ProcessQueue()
        {
            while (Logger.queue.Count > 0)
            {
                Logger.Log(Logger.queue.Dequeue());
            }
        }

        public static void Verbose(string message, bool overrideLock = false, bool inline = false)
        {
            Logger.Enqueue(message, overrideLock);
        }

        public static void Enqueue(LogMessage message, bool overrideLock = false)
        {
            if (!Logger.Locked || overrideLock)
            {
                Logger.queue.Enqueue(message);
                Logger.ProcessQueue();
            }
            else
            {
                Logger.lockedQueue.Add(message);
            }
        }

        public static void Enqueue(string message, bool overrideLock = false)
        {
            Logger.Enqueue(Logger.CreateAnonymous(message), overrideLock);
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
