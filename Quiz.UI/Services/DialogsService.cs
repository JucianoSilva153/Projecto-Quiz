using Microsoft.AspNetCore.Components;
using MudBlazor;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Common.Enum;
using Quiz.Infrastructure.Common;
using Quiz.UI.Dialogs;
using Quiz.UI.Pages.Dashboard.Accounts;
using Quiz.UI.Pages.Dashboard.Quizzes;
using Quiz.UI.Pages.Dashboard.Topics;

namespace Quiz.UI.Services;

public class DialogsService
{
    private IDialogService dialogs;

    public DialogsService(IDialogService dialogs)
    {
        this.dialogs = dialogs;
    }

    public async Task ShowInfoDialog(string title, string message, Action onDialogClose)
    {
        var parameters = new DialogParameters<InfoDialog>
        {
            { x => x.Message, message },
            { x => x.Title, title },
            { x => x.OnOkButtonClicked, onDialogClose },
        };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium };
        await dialogs.ShowAsync<InfoDialog>("Informacao", parameters, options);
    }

    public async Task ShowInfoDialog(string title, string message)
    {
        var parameters = new DialogParameters<InfoDialog>
        {
            { x => x.Message, message },
            { x => x.Title, title }
        };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium };
        await dialogs.ShowAsync<InfoDialog>("Informacao", parameters, options);
    }

    public async Task ShowAccountForm(DialogFormMode mode, AccountType accountType, AccountDto? accountDto = null,
        Action? callback = null)
    {
        var parameters = new DialogParameters<AccountFormDialog>
        {
            { x => x.Mode, mode },
            { x => x.Data, accountDto ?? new AccountDto() },
            { x => x.Type, accountType },
            { x => x.OnSaveButtonClicked, callback },
        };

        var options = new DialogOptions() { CloseButton = true, BackdropClick = false, MaxWidth = MaxWidth.ExtraLarge };
        await dialogs.ShowAsync<AccountFormDialog>("Conta", parameters, options);
    }
    
    public async Task ShowNewTopicDialog(DialogFormMode mode,Guid userId, TopicDto? topicDto = null,
        Action? callback = null)
    {
        var parameters = new DialogParameters<NewTopicDialog>
        {
            { x => x.Mode, mode },
            { x => x.Topic, topicDto ?? new TopicDto() },
            { x => x.UserId, userId },
            { x => x.OnOkButtonClicked, callback },
        };

        var options = new DialogOptions() { CloseButton = true, BackdropClick = false, MaxWidth = MaxWidth.ExtraLarge };
        await dialogs.ShowAsync<NewTopicDialog>("Novo Topico", parameters, options);
    }
    
    
    public async Task ShowSetUpKwizDialog(Guid userId, Action? callback = null)
    {
        var parameters = new DialogParameters<SetKwizDialog>
        {
            { x => x.OnSaveButtonClicked, callback },
            { x => x.userId, userId },
        };

        var options = new DialogOptions() { FullScreen = true, CloseButton = true};
        await dialogs.ShowAsync<SetKwizDialog>("Novo Kwiz", parameters, options);
    }
    public async Task ShowNewQuestionDialog(string titulo,Action<string> callback)
    {
        var parameters = new DialogParameters<NewQuestionDialog>
        {
            { x => x.OnOkButtonClicked, callback },
            { x => x.Title, titulo },
        };

        var options = new DialogOptions() { CloseButton = true};
        await dialogs.ShowAsync<NewQuestionDialog>(titulo, parameters, options);
    }
    
    public async Task ShowNewAnswerDialog(string titulo,Guid questionId, Action<string, Guid> callback)
    {
        var parameters = new DialogParameters<NewAnswerDialog>
        {
            { x => x.OnOkButtonClicked, callback },
            { x => x.Title, titulo },
            { x => x.QuestionId, questionId },
        };

        var options = new DialogOptions() { CloseButton = true};
        await dialogs.ShowAsync<NewAnswerDialog>(titulo, parameters, options);
    }
    

}