using SQLiteNotepad.ApplicationCore.Primitives.Models;

namespace SQLiteNotepad.ApplicationCore.Primitives.Interfaces;

public interface INoteService
{
    public Task AddNote(Note note);
    public Task UpdateNote(Note note);
    public Task RemoveNote(Note note);
    public Task<List<Note>> ToList();
}