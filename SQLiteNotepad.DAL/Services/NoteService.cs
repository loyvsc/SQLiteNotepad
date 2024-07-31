using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLiteNotepad.ApplicationCore.Primitives.Interfaces;
using SQLiteNotepad.ApplicationCore.Primitives.Models;
using SQLiteNotepad.DAL.Database;

namespace SQLiteNotepad.DAL.Services;

public class NoteService : INoteService
{
    private readonly ApplicationContext _applicationContext;
    private readonly ILogger<NoteService> _logger;
    
    public NoteService(ILogger<NoteService> logger, ApplicationContext applicationContext)
    {
        _logger = logger;
        _applicationContext = applicationContext;
        _logger.LogInformation("NoteService initialized");
    }
    
    public async Task AddNote(Note note, CancellationToken cancellationToken = default)
    {
        try
        {
            await _applicationContext.Notes.AddAsync(note, cancellationToken);
            await _applicationContext.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("AddNote method canceled");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"An error occurred while executing the AddNote method");
        }
    }

    public async Task UpdateNote(Note note, CancellationToken cancellationToken = default)
    {
        try
        {
            _applicationContext.Notes.Update(note);
            await _applicationContext.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("UpdateNote method canceled");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"An error occurred while executing the UpdateNote method");
        }
    }

    public async Task RemoveNote(Note note, CancellationToken cancellationToken = default)
    {
        try
        {
            _applicationContext.Notes.Remove(note);
            await _applicationContext.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("RemoveNote method canceled");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"An error occurred while executing the RemoveNote method");
        }
    }

    public async Task<List<Note>> ToList(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _applicationContext.Notes.ToListAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("ToList method canceled");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"An error occurred while executing the ToList method");
        }

        return [];
    }
}