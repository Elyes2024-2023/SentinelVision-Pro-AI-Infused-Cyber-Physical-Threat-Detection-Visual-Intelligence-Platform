#pragma once

#include <opencv2/opencv.hpp>
#include <memory>
#include <string>
#include <vector>

namespace SentinelVision {
namespace VisionEngine {

class IVisionEngine {
public:
    virtual ~IVisionEngine() = default;
    
    // Initialize the vision engine
    virtual bool Initialize() = 0;
    
    // Process a frame for object detection
    virtual bool ProcessFrame(const cv::Mat& frame) = 0;
    
    // Get detected objects in the last processed frame
    virtual std::vector<cv::Rect> GetDetectedObjects() const = 0;
    
    // Enable/disable specific detection features
    virtual void EnableFeature(const std::string& featureName, bool enable) = 0;
    
    // Get the current processing FPS
    virtual float GetCurrentFPS() const = 0;
};

class VisionEngine : public IVisionEngine {
public:
    VisionEngine();
    ~VisionEngine() override;

    bool Initialize() override;
    bool ProcessFrame(const cv::Mat& frame) override;
    std::vector<cv::Rect> GetDetectedObjects() const override;
    void EnableFeature(const std::string& featureName, bool enable) override;
    float GetCurrentFPS() const override;

private:
    class Impl;
    std::unique_ptr<Impl> pImpl;
};

} // namespace VisionEngine
} // namespace SentinelVision 