using System;
using Caliburn.Micro;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;


namespace Features.Avalonia.Results
{
    public class MessageDialogResult : ResultBase
    {
        private readonly string content;
        private readonly string title;

        public MessageDialogResult(string content, string title)
        {
            this.content = content;
            this.title = title;
        }

        public override async void Execute(CoroutineExecutionContext context)
        {
            var box = MessageBoxManager
              .GetMessageBoxStandard("title", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed...",
              ButtonEnum.YesNo);

            _ = await box.ShowAsync();

            OnCompleted();
        }
    }
}
