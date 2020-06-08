using Project.Errors;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Project.Base {

    public abstract class BaseApplication {

        // Program variables
        private bool running = false;
        private readonly Dictionary<string, Service> services = new Dictionary<string, Service>();

        private readonly Dictionary<string, BaseScreen> screens = new Dictionary<string, BaseScreen>();
        private BaseScreen defaultScreen;
        private BaseScreen currentScreen;

        // Called on load/unload
        protected abstract void Load();
        protected abstract void Unload();

        // Returns whether the application is running
        public bool IsRunning() {
            return running;
        }

        // Loads the application and its services
        public void Start() {
            if (IsRunning()) {
                throw new Exception("Application is already running.");
            }

            // Set running to true
            running = true;

            // Load app
            Load();

            // Load services
            foreach (Service service in services.Values) {
                service.Load();
            }

            // Init screens
            foreach (BaseScreen screen in screens.Values) {
                screen.Init();
            }

            // Show default screen
            if (defaultScreen == null) {
                throw new Exception("No default screen could be found");
            }

            Application.EnableVisualStyles();
            ShowScreen(defaultScreen);
            Application.Run(defaultScreen);
        }

        // Unload all services and the application
        public void Stop() {
            if (!IsRunning()) {
                throw new Exception("Application is not running.");
            }

            // Unload services
            foreach (Service service in services.Values) {
                service.Unload();
            }

            // Unload app
            Unload();

            // Set running to false to stop any running loops
            running = false;
        }

        // Register a service
        public void RegisterService(Service service) {
            services.Add(service.GetHandle(), service);
        }

        // Returns a service by its handle
        public T GetService<T>(string handle) where T: Service {
            // Return empty value if service does not exist
            if (!services.TryGetValue(handle, out Service service)) {
                return default;
            }

            // Cast service and return
            return (T) Convert.ChangeType(service, typeof(T));
        }

        // Register a screen
        public void RegisterScreen(BaseScreen screen) {
            screens.Add(screen.GetHandle(), screen);

            // Set as default if its the default screen
            if(screen.IsDefault()) {
                defaultScreen = screen;
            }
        }

        // Returns a screen by its handle
        public T GetScreen<T>(string handle) where T: BaseScreen {
            // Return empty value if screen does not exist
            if (!screens.TryGetValue(handle, out BaseScreen screen)) {
                return default;
            }

            // Cast screen and return
            return (T) Convert.ChangeType(screen, typeof(T));
        }

        public BaseScreen GetDefaultScreen() {
            return defaultScreen;
        }

        public BaseScreen GetCurrentScreen() {
            return currentScreen;
        }

        public void ShowScreen(BaseScreen screen) {
            UserService userService = GetService<UserService>("users");
            User user = userService.GetCurrentUser();

            if(screen == null) {    
                throw new ArgumentException("Screen can't be null");
            }

            // Check user permissions
            bool allowAuthCheck = !screen.IsDefault();

            if((screen.RequireLogin() || screen.RequireAdmin()) && user == null && allowAuthCheck) {
                GuiHelper.ShowError("Je moet ingelogd zijn om dit scherm te bekijken");
                return;
            }

            if (screen.RequireAdmin() && !user.admin && allowAuthCheck) {
                GuiHelper.ShowError("Je moet een admin zijn om dit scherm te bekijken");
                return;
            }

            // Show if not already visible
            if (currentScreen == null || screen.GetHandle() != currentScreen.GetHandle()) {
                try {
                    screen.OnShow();

                    // Hide current screen
                    if (currentScreen != null) {
                        currentScreen.Hide();
                    }

                    // Show new  screen
                    screen.Show();
                    currentScreen = screen;
                } catch(PermissionException e) {
                    GuiHelper.ShowError(e.Message);
                } catch(Exception e) {
                    GuiHelper.ShowError("Interne error: " + e.Message);
                }
            }
        }

    }

}
