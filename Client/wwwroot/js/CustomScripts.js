/*Word carousal in index.razor*/
// Most of this code is applied to the index.razor, see /page.js for respectice js code.

//Day and Night

let url = "https://lsnpersonalstorage.blob.core.windows.net/jobrelatedfiles/Lawrence%20Neris%20Software%20Engineer%20Resume.pdf?sp=r&st=2023-12-06T05:35:08Z&se=2024-12-06T13:35:08Z&spr=https&sv=2022-11-02&sr=b&sig=PpV0xNR8s7Y4VI%2BC%2BSwVd7PXYvowfPSEJm9vPJLRUmo%3D";
function openInNewTab(url) {
    window.open(url, '_blank');
}


function toggleDayNightMode() {
    var html = document.documentElement;
    if (html.classList.contains('night-mode')) {
        html.classList.remove('night-mode');
        html.classList.add('day-mode');
    } else {
        html.classList.remove('day-mode');
        html.classList.add('night-mode');
    }
    // Optionally save the current mode to local storage
    localStorage.setItem('theme', html.classList.contains('night-mode') ? 'night-mode' : 'day-mode');
}

// Apply the saved theme on page load
document.addEventListener('DOMContentLoaded', () => {
    var savedTheme = localStorage.getItem('theme') || 'day-mode';
    document.documentElement.classList.add(savedTheme);
});



//wordcarousel///////////////////////////////
window.startWordCarousel = () => {
    const words = ["learning.", "traveling.", "lifting."];
    let currentWordIndex = 0;
    const wordCarousel = document.getElementById('wordCarousel');

    // Function to update the word
    function updateWord() {
        wordCarousel.classList.remove('fade-in');
        wordCarousel.classList.add('fade-out');

        // Wait for fade-out transition to finish before changing the word and fading in
        setTimeout(() => {
            currentWordIndex = (currentWordIndex + 1) % words.length;
            wordCarousel.textContent = words[currentWordIndex];
            wordCarousel.classList.remove('fade-out');
            wordCarousel.classList.add('fade-in');
        }, 500); // This should match the transition time
    }

    // Start the carousel effect
    setInterval(updateWord, 2000); // Change word every 3 seconds
};



/*testing this*/
// function navigateToAbout() {
//     window.location.href = 'about';
// }
// function navigateToKnowledge() {
//     window.location.href = 'knowledge';
// }

// function navigateToExperience() {
//     window.location.href = 'experience';
// }

// function navigateToProjects() {
//     window.location.href = 'projects';
// }

// Make sure to expose the functions to the window object if they are not already global
// window.navigateToAbout = navigateToAbout;
// window.navigateToKnowledge = navigateToKnowledge;
// window.navigateToExperience = navigateToExperience;
// window.navigateToProjects = navigateToProjects;

/**/


/*s*/


// Function when the Knowledge button is clicked
function GoToKnowledge() {
    console.log("Knowledge button clicked!");
    // Implement the functionality, e.g., navigate to a section
    // window.location.href = 'url-to-knowledge-section';
}

// Function when the Experience button is clicked
function GoToExperience() {
    console.log("Experience button clicked!");
    // Implement the functionality, e.g., navigate to a section
    // window.location.href = 'url-to-experience-section';
}

// Function when the Projects button is clicked
function GoToProjects() {
    console.log("Projects button clicked!");
    // Implement the functionality, e.g., navigate to a section
    // window.location.href = 'url-to-projects-section';
}




/*s*/

