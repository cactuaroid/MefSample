using MefSample.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MefSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MefManager.Initialize();

            var taro = new Person("Taro");
            var jiro = new Person("Jiro");

            taro.LeaveMessage("I'm Taro!");
            jiro.LeaveMessage("I'm Jiro!");

            Console.WriteLine("===== MessageStorage.Messages =====");
            foreach (var message in MefManager.Container.GetExportedValue<MessageStorage>().Messages)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("===================================");
        }
    }

    public class Person : IPartImportsSatisfiedNotification
    {
        [Import]
        private Logger m_logger = null;

        [Import]
        private MessageStorage m_storage = null;

        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;

            // m_logger.Info(Name + " before ComposeParts"); // NullReferenceException
            MefManager.Container.ComposeParts(this);
            m_logger.Info(Name + " after ComposeParts");
        }

        public void LeaveMessage(string message)
        {
            m_storage.Add(message);
        }

        public void OnImportsSatisfied()
        {
            m_logger.Info(Name + " got parts");
        }
    }

    [Export]
    public class MessageStorage
    {
        [Import]
        private Logger m_logger = null;

        public string[] Messages
        {
            get { return m_messages.ToArray(); }
        }

        private List<string> m_messages = new List<string>();

        public void Add(string message)
        {
            m_logger.Info("[" + message + "]");
            m_messages.Add(message);
        }
    }
}
