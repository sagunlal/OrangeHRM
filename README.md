Here’s the updated **README.md** file with the project name **OrangeHRM**:

---

# OrangeHRM Test Automation

## Description
This project is an automated testing suite for **OrangeHRM** using **Selenium WebDriver**, **NUnit**, and **C#**. It performs various UI tests to ensure the functionality of the **OrangeHRM** application.

## Prerequisites

Before running the tests, ensure you have the following installed:

- **Visual Studio** or **Visual Studio Code** (with C# support)
- **.NET SDK** (for running C# code)
- **NUnit** (for testing framework)
- **Selenium WebDriver** (for browser automation)
- **WebDriverManager** (for managing browser drivers)
- **ChromeDriver** or other browser drivers (depending on your browser choice)

## Installation

### 1. Clone the repository:
```bash
git clone https://github.com/your-username/OrangeHRM.git
```

### 2. Open the project in Visual Studio:
   - Open **Visual Studio** and select **Open Project**.
   - Navigate to the folder where you cloned the repository and select the project file (`.csproj`).

### 3. Install Dependencies:
   The project uses NuGet packages for testing and browser automation. You can restore them by running:
   
   ```bash
   dotnet restore
   ```
## Running the Tests

### 1. Using Visual Studio:

   - Open the **Test Explorer** in Visual Studio (usually under `Test` > `Windows` > `Test Explorer`).
   - You should see the list of tests under the project.
   - Select the test(s) you want to run and click the **Run All** or **Run** button.


## Test Reporting

The tests are configured to generate an HTML report after execution in the build folder.

### 1. View HTML Reports:
   After running the tests, the results will be saved in the `TestResults` folder within your project. You can open the HTML report in a browser.

### 2. Example of Test Report File Location:
   - `./TestResults/test-report.html`

