using System;
using static System.Console;
using System.Collections.Generic;
/*Реализуйте с использованием паттернов проектирования простейшую систему планирования задач.
Должна быть возможность создания списка дел, установки приоритетов,
установки дат выполнения, удаление и изменения дел. Каждому делу можно установить тег.
Список дел можно загружать и сохранять в файл.
Необходимо реализовать возможность поиска конкретного дела.
Критерии поиска: по датам, по тегам, по приоритету и так далее.*/
namespace TaskSchedulingSystem_ChmilRV
{
    public interface INote
    {
        void NoteParty();
        void NoteBirthday();
        void NoteReminder();
    }
    public class CreateNote : INote
    {
        private Note note = new Note();
        public CreateNote() { Reset(); }
        public void Reset() { note = new Note(); }
        public void NoteParty() { note.Add("Запись о мероприятии"); }
        public void NoteBirthday() { note.Add("Запись о дне рождения"); }
        public void NoteReminder() { note.Add("Напоминание"); }
        public Note GetNote()
        {
            Note resultNote = note;
            Reset();
            return resultNote;
        }
    }
    public class Note
    {
        private List<object> notes = new List<object>();
        public void Add(string part) { notes.Add(part); }
        public string ListNotes()
        {
            string str = string.Empty;
            for (int i = 0; i < notes.Count; i++) { str += notes[i] + ", "; }
            str = str.Remove(str.Length - 2);
            return "Заметки: " + str + "\n";
        }
    }
    public class Dairy
    {
        private INote note;
        public INote Note { set { note = value; } }
        public void makeSimpleNote() { note.NoteReminder(); }
        public void makeManyNotes()
        {
            note.NoteParty();
            note.NoteBirthday();
            note.NoteReminder();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dairy dairy = new Dairy();
            CreateNote note = new CreateNote();
            dairy.Note = note;
            WriteLine("Одиночная запись:");
            dairy.makeSimpleNote();
            WriteLine(note.GetNote().ListNotes());
            WriteLine("Групповая запись:");
            dairy.makeManyNotes();
            WriteLine(note.GetNote().ListNotes());
            WriteLine("Настраиваемая запись:");
            note.NoteParty();
            note.NoteReminder();
            note.NoteBirthday();
            note.NoteParty();
            note.NoteReminder();
            note.NoteParty();
            Write(note.GetNote().ListNotes());
            ReadKey();
        }
    }
}
