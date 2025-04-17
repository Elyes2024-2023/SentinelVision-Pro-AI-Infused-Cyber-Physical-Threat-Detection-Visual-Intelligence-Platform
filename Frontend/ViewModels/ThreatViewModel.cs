/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Threat View Model
 * This file defines the view model for threat data in the frontend
 */

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SentinelVisionPro.Frontend.ViewModels
{
    /// <summary>
    /// View model for threat data in the frontend
    /// </summary>
    public class ThreatViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        private ObservableCollection<ThreatItem> _threats;
        private bool _isLoading;
        private string _errorMessage;

        /// <summary>
        /// Initializes a new instance of the ThreatViewModel
        /// </summary>
        public ThreatViewModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/");
            _threats = new ObservableCollection<ThreatItem>();
            
            LoadThreatsCommand = new RelayCommand(async () => await LoadThreatsAsync());
            RefreshCommand = new RelayCommand(async () => await LoadThreatsAsync());
        }

        /// <summary>
        /// Gets or sets the collection of threats
        /// </summary>
        public ObservableCollection<ThreatItem> Threats
        {
            get => _threats;
            set
            {
                _threats = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether data is currently loading
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the command to load threats
        /// </summary>
        public ICommand LoadThreatsCommand { get; }

        /// <summary>
        /// Gets the command to refresh threats
        /// </summary>
        public ICommand RefreshCommand { get; }

        /// <summary>
        /// Loads threats from the API
        /// </summary>
        private async Task LoadThreatsAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = null;

                var response = await _httpClient.GetAsync("api/ThreatDetection");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var threats = JsonSerializer.Deserialize<ThreatItem[]>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Threats.Clear();
                foreach (var threat in threats)
                {
                    Threats.Add(threat);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading threats: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Event raised when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// Represents a threat item in the UI
    /// </summary>
    public class ThreatItem
    {
        /// <summary>
        /// Gets or sets the ID of the threat
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the threat
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the severity of the threat
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the threat
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets whether the threat is resolved
        /// </summary>
        public bool IsResolved { get; set; }
    }

    /// <summary>
    /// Simple implementation of ICommand
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<Task> _executeAsync;

        /// <summary>
        /// Initializes a new instance of the RelayCommand
        /// </summary>
        /// <param name="execute">The action to execute</param>
        public RelayCommand(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand
        /// </summary>
        /// <param name="executeAsync">The async action to execute</param>
        public RelayCommand(Func<Task> executeAsync)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        }

        /// <summary>
        /// Determines whether the command can execute in its current state
        /// </summary>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Executes the command
        /// </summary>
        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute();
            }
            else if (_executeAsync != null)
            {
                _executeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Event raised when the ability to execute the command changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
} 