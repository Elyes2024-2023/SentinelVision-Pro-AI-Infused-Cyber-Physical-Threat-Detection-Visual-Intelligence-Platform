cmake_minimum_required(VERSION 3.20)
project(SentinelVisionCore VERSION 1.0.0 LANGUAGES CXX)

# Set C++ standard
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Find required packages
find_package(OpenCV REQUIRED)
find_package(CUDA REQUIRED)

# Add subdirectories
add_subdirectory(VisionEngine)
add_subdirectory(SystemMonitor)
add_subdirectory(ThreatDetection)

# Set output directories
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)

# Global include directories
include_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}/include
    ${OpenCV_INCLUDE_DIRS}
    ${CUDA_INCLUDE_DIRS}
)

# Global compile definitions
add_definitions(-DSENTINEL_VISION_PRO)
add_definitions(-D_CRT_SECURE_NO_WARNINGS)

# Global compile options
if(MSVC)
    add_compile_options(/W4 /WX)
else()
    add_compile_options(-Wall -Wextra -Werror)
endif()

# Install targets
install(DIRECTORY include/
    DESTINATION include
    FILES_MATCHING PATTERN "*.h"
)

# Export targets
export(TARGETS SentinelVisionCore
    FILE "${CMAKE_BINARY_DIR}/SentinelVisionCoreTargets.cmake"
) 