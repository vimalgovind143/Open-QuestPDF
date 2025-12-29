/**
 * QuestPDF Report Generator - Enhanced JavaScript
 */

// Document ready function
document.addEventListener('DOMContentLoaded', function() {
    console.log('QuestPDF Report Generator initialized');

    // Initialize tooltip
    initializeTooltips();

    // Initialize report generation handlers
    initializeReportGeneration();

    // Initialize smooth scrolling
    initializeSmoothScrolling();

    // Initialize navigation effects
    initializeNavigationEffects();

    // Initialize form enhancements
    initializeFormEnhancements();
});

/**
 * Initialize tooltip functionality
 */
function initializeTooltips() {
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

/**
 * Initialize report generation handlers with enhanced feedback
 */
function initializeReportGeneration() {
    const reportLinks = document.querySelectorAll('a[href*="GenerateReport"], a[href*="/api/"]');

    reportLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            // Show enhanced loading indicator
            const originalContent = this.innerHTML;
            const loadingHtml = `
                <span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
                <span>Generating PDF...</span>
            `;
            this.innerHTML = loadingHtml;
            this.classList.add('disabled');
            this.setAttribute('aria-disabled', 'true');

            // Add visual feedback to parent card
            const card = this.closest('.card');
            if (card) {
                card.classList.add('generating');
            }

            // Show global notification
            showTemporaryNotification('Generating your PDF report...', 'info');

            // The actual navigation will proceed normally
            // We don't prevent default, just enhance the UX
        });
    });
}

/**
 * Show temporary notification
 */
function showTemporaryNotification(message, type = 'info') {
    // Create notification element
    const notification = document.createElement('div');
    notification.className = `alert alert-${type} alert-dismissible fade show position-fixed bottom-0 end-0 m-3`;
    notification.style.zIndex = '1050';
    notification.style.maxWidth = '350px';
    notification.role = 'alert';

    notification.innerHTML = `
        <strong>${getNotificationTitle(type)}</strong> ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `;

    document.body.appendChild(notification);

    // Auto-dismiss after 5 seconds
    setTimeout(() => {
        notification.classList.remove('show');
        setTimeout(() => notification.remove(), 300);
    }, 5000);
}

/**
 * Get notification title based on type
 */
function getNotificationTitle(type) {
    const titles = {
        'info': 'Info:',
        'success': 'Success:',
        'warning': 'Warning:',
        'danger': 'Error:',
        'primary': 'Notice:'
    };
    return titles[type] || 'Info:';
}

/**
 * Initialize smooth scrolling for anchor links
 */
function initializeSmoothScrolling() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();

            const targetId = this.getAttribute('href');
            if (targetId === '#') return;

            const targetElement = document.querySelector(targetId);
            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: 'smooth'
                });
            }
        });
    });
}

/**
 * Initialize navigation effects
 */
function initializeNavigationEffects() {
    // Navbar scroll effect
    const navbar = document.querySelector('.navbar');
    if (navbar) {
        window.addEventListener('scroll', () => {
            if (window.scrollY > 50) {
                navbar.classList.add('navbar-scrolled');
            } else {
                navbar.classList.remove('navbar-scrolled');
            }
        });
    }

    // Add active class to current nav item
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        if (link.href === window.location.href) {
            link.classList.add('active');
            link.setAttribute('aria-current', 'page');
        }
    });
}

/**
 * Initialize form enhancements
 */
function initializeFormEnhancements() {
    // Add input focus effects
    const formControls = document.querySelectorAll('.form-control');
    formControls.forEach(input => {
        input.addEventListener('focus', function() {
            this.closest('.form-group')?.classList.add('focused');
        });

        input.addEventListener('blur', function() {
            this.closest('.form-group')?.classList.remove('focused');
        });
    });
}

/**
 * Enhanced error handling for report generation
 */
function handleReportError(error) {
    console.error('Report generation error:', error);

    // Show error notification
    showTemporaryNotification('Failed to generate report. Please try again.', 'danger');

    // Reset any loading states
    const loadingElements = document.querySelectorAll('.disabled[aria-disabled="true"]');
    loadingElements.forEach(el => {
        el.classList.remove('disabled');
        el.removeAttribute('aria-disabled');
    });

    // Reset card states
    const generatingCards = document.querySelectorAll('.card.generating');
    generatingCards.forEach(card => {
        card.classList.remove('generating');
    });
}

/**
 * Add fade-in animation to elements when they come into view
 */
function initializeScrollAnimations() {
    const fadeElements = document.querySelectorAll('.fade-in');

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
            }
        });
    }, {
        threshold: 0.1
    });

    fadeElements.forEach(el => {
        observer.observe(el);
    });
}

/**
 * Initialize all components
 */
function initializeAll() {
    initializeTooltips();
    initializeReportGeneration();
    initializeSmoothScrolling();
    initializeNavigationEffects();
    initializeFormEnhancements();
    initializeScrollAnimations();
}

// Export functions for external use if needed
if (typeof module !== 'undefined' && module.exports) {
    module.exports = {
        initializeAll,
        showTemporaryNotification,
        handleReportError
    };
}

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', initializeAll);