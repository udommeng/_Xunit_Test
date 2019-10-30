namespace App01 {
    public interface ICounter {
        int Count { get; }
        void Inc();
        void Reset();
    }
}