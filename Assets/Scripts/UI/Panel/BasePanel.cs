using UnityEditor.Search;
using UnityEngine;

namespace HOG
{
    public abstract class BasePanel : MonoBehaviour
    {
        public abstract void Show();
        public abstract void Hide();
    }
}