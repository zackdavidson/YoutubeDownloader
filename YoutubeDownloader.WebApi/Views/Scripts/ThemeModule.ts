/**
 * This is the storage key
 * */
const THEME_KEY: string = 'theme-mode';

/**
 *
 * Handles the theming system stuff, contains theme state
 *
 * */
class ThemeModule {
    
    private darkMode: boolean = true;
    
    constructor() { }
    
    getModeText(): string {
        return this.darkMode === true ? "Dark" : "Light";
    };

    changeMode(): void {
        this.darkMode = !this.darkMode;
        this.transformPage();
        this.setMode(this.darkMode);
    }

    setMode(darkMode): void {
        let element = document.getElementById('theme-changer-label');
        let radioButton = document.getElementById("theme-changer");

        if (darkMode === true) {
            document.documentElement.setAttribute('data-theme', 'dark');
            element.innerText = 'Dark';
            // @ts-ignore
            radioButton.checked = true;
        } else {
            document.documentElement.setAttribute('data-theme', 'light');
            element.innerText = 'Light';
            // @ts-ignore
            radioButton.checked = false;
        }

        localStorage.setItem(THEME_KEY, this.darkMode + "");
    };   

    private transformPage(): void {
        document.documentElement.classList.add('theme-trans');
        window.setTimeout(() => {
            document.documentElement.classList.remove('theme-trans');
        }, 250);
    };

    init(): void {
        console.log('init')
        let storageMode = localStorage.getItem(THEME_KEY);
        if (storageMode !== null) {
            this.darkMode = (storageMode === 'true');
        }
        this.setMode(this.darkMode);
    };
}



const theme = new ThemeModule();
theme.init();