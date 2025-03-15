export function toggleTheme(toggle: boolean): void {
    if (toggle) {
        document.body.classList.add("light");
    }
    else {
        document.body.classList.remove("light");
    }
}