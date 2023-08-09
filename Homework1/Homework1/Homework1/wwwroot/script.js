const getAllUsersButton = document.getElementById("getAllUsers");
const usersListDiv = document.getElementById("usersList");
const getUserByNameButton = document.getElementById("getUserByName");
const userNameInput = document.getElementById("userNameInput");
const userResultDiv = document.getElementById("userResult");

const apiUrl = "https://localhost:7200/api/users";

getAllUsersButton.addEventListener("click", async () => {
    try {
        const response = await fetch(apiUrl);
        const data = await response.json();
        usersListDiv.innerHTML = data.join("<br>");
    } catch (error) {
        console.error("Error fetching users:", error);
    }
});

getUserByNameButton.addEventListener("click", async () => {
    const userName = userNameInput.value;
    if (!userName) {
        userResultDiv.textContent = "Please enter a user name.";
        return;
    }

    try {
        const response = await fetch(`${apiUrl}/${userName}`);
        if (response.status === 404) {
            userResultDiv.textContent = "User not found.";
            return;
        }
        const data = await response.text();
        userResultDiv.textContent = data;
    } catch (error) {
        console.error("Error fetching user:", error);
    }
});