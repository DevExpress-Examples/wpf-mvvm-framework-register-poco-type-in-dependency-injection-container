using System;

namespace Common {
    public interface IDetailViewModel {
        void SetCurrentItem(int id, Action<int> onItemUpdated);
    }
}
