namespace exercise.wwwapi.Helpers
{
    public class IdGenerator
    {
        private int _nextId = 1;

        public int GetNextId()
        {
            return _nextId++;
        }
    }
}
