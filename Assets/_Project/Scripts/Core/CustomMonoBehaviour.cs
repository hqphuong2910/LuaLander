using UnityEngine;

namespace Assets._Project.Scripts.Core {
    /// <summary>
    /// An abstract class inherited from <see cref="MonoBehaviour"/>.
    /// It is highly recommended that all Unity scripts in this project
    /// inherit from this class instead of <see cref="MonoBehaviour"/>.
    /// </summary>
    public abstract class CustomMonoBehaviour : MonoBehaviour {
        private bool isStarted;

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Go to definition to see what it is exactly doing.
        /// </summary>
        protected virtual void Awake() {
            LoadSelf();
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Go to definition to see what it is exactly doing.
        /// </summary>
        protected virtual void OnEnable() {
            if (isStarted) {
                SubscribeEvents();
            }
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Go to definition to see what it is exactly doing.
        /// </summary>
        protected virtual void Reset() {
            LoadSelf();
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Go to definition to see what it is exactly doing.
        /// </summary>
        protected virtual void Start() {
            isStarted = true;

            LoadDependencies();
            SubscribeEvents();
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Go to definition to see what it is exactly doing.
        /// </summary>
        protected virtual void OnDestroy() {
            if (isStarted) {
                UnsubscribeEvents();
            }
        }

        /// <summary>
        /// Initialize and load values, components, etc. owned by this script instance (<see cref="GameObject"/>).
        /// </summary>
        protected virtual void LoadSelf() {
        }

        /// <summary>
        /// Get and load values, components, etc. not owned by this script instance (<see cref="GameObject"/>).
        /// </summary>
        protected virtual void LoadDependencies() { }

        /// <summary>
        /// Subscribe to relevant events.
        /// </summary>
        protected virtual void SubscribeEvents() { }

        /// <summary>
        /// Unsubscribe from events to prevent memory leaks or unwanted callbacks.
        /// </summary>
        protected virtual void UnsubscribeEvents() { }
    }
}
