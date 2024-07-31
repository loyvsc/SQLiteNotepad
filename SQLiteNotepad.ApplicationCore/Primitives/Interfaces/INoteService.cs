using SQLiteNotepad.ApplicationCore.Primitives.Models;

namespace SQLiteNotepad.ApplicationCore.Primitives.Interfaces;

public interface INoteService
{
    public Task AddNote(Note note, CancellationToken cancellationToken = default);
    public Task UpdateNote(Note note, CancellationToken cancellationToken = default);
    public Task RemoveNote(Note note, CancellationToken cancellationToken = default);
    public Task<List<Note>> ToList();
}