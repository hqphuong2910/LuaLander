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
        /// Navigate to see what it is exactly doing.
        /// </summary>
        protected virtual void Awake() {
            LoadComponents();
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Navigate to see what it is exactly doing.
        /// </summary>
        protected virtual void OnEnable() {
            if (isStarted) {
                SubscribeEvents();
            }
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Navigate to see what it is exactly doing.
        /// </summary>
        protected virtual void Reset() {
            LoadComponents();
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Navigate to see what it is exactly doing.
        /// </summary>
        protected virtual void Start() {
            isStarted = true;

            LoadDependencies();
            SubscribeEvents();
        }

        /// <summary>
        /// Only override if you really want to implement custom behaviours in this method.
        /// Navigate to see what it is exactly doing.
        /// </summary>
        protected virtual void OnDisable() {
            if (isStarted) {
                UnsubscribeEvents();
            }
        }

        /// <summary>
        /// Initializes and loads components of the script instance.
        /// </summary>
        protected virtual void LoadComponents() {
        }

        /// <summary>
        /// Loads required dependencies (such as references to other scripts) of the script instance.
        /// </summary>
        protected virtual void LoadDependencies() { }

        /// <summary>
        /// Subscribes to relevant events.
        /// </summary>
        protected virtual void SubscribeEvents() { }

        /// <summary>
        /// Unsubscribes from events to prevent memory leaks or unwanted callbacks.
        /// </summary>
        protected virtual void UnsubscribeEvents() { }
    }
}
