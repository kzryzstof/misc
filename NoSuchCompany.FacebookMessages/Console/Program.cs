using System;
using System.Linq;
using NoSuchCompany.FacebookMessages.Core.ViewModels;

namespace NoSuchCompany
{
    class Program
    {
        static void Main(string[] args)
        {
           var viewModel = new MainWindowViewModel();

            const string Path = "/Users/christophe/nosuch-company/NoSuchCompany.FacebookMessages/Data/facebook-christophecommeyne_1/messages/inbox";
            viewModel.LoadConversations(Path, "Christophe Commeyne");

            //  Configure the console.
            
            bool searchUi = false;
            
            bool printConversation = true;
            var conversationId = 66;
            
            // -----------------------------------------------------
            // -- Used to find conversation with Julie Couture (#49)
            // -----------------------------------------------------

            if (searchUi)
            {
                Console.Clear();

                foreach (ConversationViewModel conversation in viewModel.Conversations.Where(c => c.Messages.Any()).OrderBy(c => c.MostRecentMessage.Timestamp))
                {
                    if (false == conversation.Messages.Any())
                        continue;

                    Console.WriteLine($"{conversation.Summary}");
                }
            }


            if (printConversation)
            {
                // ----------------------------------------------------------
                // -- Used to print the conversation with Julie Couture (#49)
                // ----------------------------------------------------------

                Console.Clear();

                foreach (MessageViewModel message in viewModel.Conversations.First(c => c.Id == conversationId).Messages.OrderBy(m => m.Timestamp))
                {
                    if (false == message.IsFromOwner)
                    {
                        Console.WriteLine($"{message.Timestamp.ToLocalTime().ToString("F")}");
                        Console.WriteLine($"{message.Sender}");
                        Console.WriteLine($"{message.Message}");
                    }
                    else
                    {
                        Console.WriteLine($"{message.Timestamp.ToLocalTime().ToString("F"), 150}");
                        Console.WriteLine($"{message.Sender, 150}");
                        Console.WriteLine($"{message.Message, 150}");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            // //    Simple print.
            // while (true)
            // {
            //     Console.Clear();
            //     
            //     foreach (ConversationHeaderViewModel header in viewModel.ConversationHeaders)
            //         Console.WriteLine($"{header.Id:##0} - {header.Title}");
            //
            //     int convId = Int32.Parse(Console.ReadLine());
            //
            //     Console.Clear();
            //
            //     foreach (MessageViewModel message in viewModel.Conversations.First(c => c.Id == convId).Messages)
            //         Console.WriteLine($"{message.Sender}: {message.Message}");
            //
            //     Console.ReadLine();
            // }
            
            // Console.Clear();
            //
            // var conversation = viewModel.Find("on est rentr").First();
            //     
            // foreach (MessageViewModel message in viewModel.Conversations.First(c => c.Id == conversation.Id).Messages)
            //     Console.WriteLine($"{message.Sender}: {message.Message}");
            //
            Console.ReadLine();
        }
    }
}