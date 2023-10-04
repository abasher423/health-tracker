# health-tracker-app

Health Tracker is a full-stack web application built using C#, .NET 6, Angular and TypeScript. It enables users to track their health-related data, including nutrition and exercise. The application provides an intuitive user interface for logging and visualizing health data, as well as features for setting goals, generating reports and more.

**Why I used the technologies**

As a full-stack software engineer, I have chosen to specialise in .NET and Angular technologies. This decision stems from my desire to gain comprehensive knowledge and expertise in these technologies, and personal projects provide an excellent opportunity for hands-on experience. By utilizing these technologies, I can enhance my skills and proficiency in their development.

Furthermore, the decision to use .NET and Angular is supported by the fact that both frameworks have large and active communities. These communities offer extensive documentation, resources, and a vibrant ecosystem. As an active member of these communities, I aim to stay updated with the latest industry trends and best practices through this project.

Additionally, the scalability and performance capabilities of .NET and C# make them suitable choices for the health tracker application. These technologies offer features such as just-in-time compilation, efficient memory management, and performance optimizations. Leveraging these capabilities ensures that the application can handle high traffic, process data efficiently, and provide a seamless user experience.

Overall, my choice to utilize .NET and Angular technologies for this project serves the purpose of personal growth, staying connected to the community, and leveraging the performance and scalability benefits these technologies offer.

## Requirements

User Registration and Account Management:

1. Users should be able to register for an account using their email and password.
   - The system should validate user input during registration to ensure data integrity.
   - Users should have the ability to update their account information and manage their privacy settings.
2. User Profile Creation and Health Data Input:
   - Users should be able to create and maintain a comprehensive profile with health-related information, including age, height, weight, and gender.
   - The system should allow users to input and track various health metrics, such as physical activity, nutrition, sleep, heart rate, and blood pressure.
   - Users should have the option to import health data from compatible devices or applications, such as fitness trackers or smartwatches.
3. Analytics and Data Visualization:
   - The system should generate meaningful analytics based on the user's health data, providing insights into their overall well-being.
Analytics should include metrics like BMI, body fat percentage, ideal weight range, daily calorie intake, and sleep quality.
   - The system should present analytics in visually appealing and easy-to-understand charts, graphs, and dashboards.
4. Goal Setting and Tracking:
   - Users should be able to set personalized health goals, such as weight loss, exercise targets, or dietary objectives.
   - The system should support goal tracking, displaying users' progress towards their goals over time.
   - Users should receive regular updates and notifications to stay motivated and on track with their goals.
5. Journaling and Logging:
   - Users should be able to maintain a digital health journal to record additional details about their activities, emotions, or observations.
   - The system should allow users to log specific details for each health metric, such as exercise duration, food consumed, or symptoms experienced.
   - Users should have the ability to add notes or comments to their journal entries.
6. Security and Privacy:
   - The system should prioritize the security and privacy of user data, employing encryption techniques and secure protocols for data 7. Transmission and storage.
   - Users' personal health information should be kept confidential and should only be accessible to authorized individuals.
   - The system should comply with relevant data protection regulations, such as GDPR or HIPAA, to ensure user privacy.
8. User-Friendly Interface and Navigation:
   - The system should have an intuitive and visually appealing user interface, with easy-to-use navigation menus and controls.
   - Users should be able to navigate between different sections of the application seamlessly.
   - The user interface should be responsive, adapting to various screen sizes and devices.
9.Support and Help:
   - The system should provide user support, including a help center, FAQs, or a contact form for users to seek assistance or report issues.
   - Help documentation should be available, offering guidance on using the application's features and functionalities.

## Database Design

The following diagram is an ERD (Entity-Relationship Diagram) which is a visual representation of the entities within the system and the relationships between them.

![Model databases](https://github.com/abasher423/health-tracker-app/assets/56160528/da356aa8-e907-41f7-b2f4-d3625570e279)


## Security

I have decided to use RSA and here is my thought process:

1. HS256 (HMAC-SHA256): HS256 uses a symmetric key to both sign and verify the token. This means that the same secret key is used for both token creation and validation. HS256 can provide a good level of security if you can securely manage and protect the secret key. It is relatively simple to implement and performant.
2. SHA256: SHA256 is a cryptographic hash function, not a signing algorithm. It is commonly used in combination with other algorithms, such as RSA or ECDSA. If you are considering SHA256 alone, it may not be sufficient for token validation, as it does not provide a built-in mechanism for signing or verifying tokens.
3. RS256 (RSA with SHA-256): RS256 is an asymmetric algorithm that uses a public-private key pair. The token issuer signs the token with the private key, and the receiver validates the signature using the corresponding public key. RS256 provides strong security and is widely used for token-based authentication. However, it requires the management of key pairs and the public key infrastructure (PKI).

Considering the nature of a health tracker application, which may involve sensitive personal health information, it is generally recommended to use RS256. This algorithm offers robust security by utilizing asymmetric cryptography and provides a higher level of trust and assurance.
Implementing RS256 may require additional setup and management of keys, but it offers greater security benefits, especially when dealing with sensitive user data. However, the final decision should be based on your specific needs, the level of security required, and the resources available for key management.

### Authentication
To authenticate users in HealthTracker, I chose to implement JSON Web Token (JWT) authentication. This approach offers several benefits, including stateless authentication, scalability, and flexibility. Here's how I implemented JWT authentication:

1. Login Endpoint: I created an API endpoint that accepts login credentials (such as email and password) from the user.
User Validation: After receiving the login credentials, I validated them against the user repository to ensure the user exists and the provided information is correct.
2. JWT Generation: Once the user credentials are validated, I generate a JWT using a secure token provider. This JWT serves as a digital identity token for the authenticated user.
3. Token Return: The generated JWT is returned to the client, allowing them to include it in subsequent API requests for authentication.
4. By implementing JWT authentication, HealthTracker ensures secure and efficient user authentication without the need for server-side sessions. This approach provides an added layer of protection for the sensitive data handled by the application.

### Secure API Requests
To ensure that only authenticated users can access certain API endpoints and protect sensitive data, I utilized the [Authorize] attribute in my API endpoints. By applying this attribute, only users with valid JWT tokens can access the protected routes. This helps maintain the confidentiality and integrity of the data exchanged between the client and the server.

Overall, the implementation of security and authentication measures in HealthTracker reflects my commitment to safeguarding user information and maintaining a secure environment for handling sensitive health data.

