#pragma once

#include <string>
#include <vector>
#include <memory>
#include <chrono>

namespace SentinelVision {
namespace SystemMonitor {

struct SystemMetrics {
    double cpuUsage;
    double memoryUsage;
    double diskUsage;
    double networkUsage;
    std::chrono::system_clock::time_point timestamp;
};

struct ProcessInfo {
    std::string name;
    uint32_t pid;
    double cpuUsage;
    double memoryUsage;
    std::string status;
};

class ISystemMonitor {
public:
    virtual ~ISystemMonitor() = default;
    
    // Initialize the system monitor
    virtual bool Initialize() = 0;
    
    // Get current system metrics
    virtual SystemMetrics GetSystemMetrics() const = 0;
    
    // Get list of running processes
    virtual std::vector<ProcessInfo> GetRunningProcesses() const = 0;
    
    // Monitor specific process by PID
    virtual bool MonitorProcess(uint32_t pid) = 0;
    
    // Stop monitoring specific process
    virtual bool StopMonitoringProcess(uint32_t pid) = 0;
    
    // Get alerts for suspicious activity
    virtual std::vector<std::string> GetAlerts() const = 0;
};

class SystemMonitor : public ISystemMonitor {
public:
    SystemMonitor();
    ~SystemMonitor() override;

    bool Initialize() override;
    SystemMetrics GetSystemMetrics() const override;
    std::vector<ProcessInfo> GetRunningProcesses() const override;
    bool MonitorProcess(uint32_t pid) override;
    bool StopMonitoringProcess(uint32_t pid) override;
    std::vector<std::string> GetAlerts() const override;

private:
    class Impl;
    std::unique_ptr<Impl> pImpl;
};

} // namespace SystemMonitor
} // namespace SentinelVision 