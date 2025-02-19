declare const LeaderLine: any;

const main = document.getElementsByTagName('main')[0];

export function addHandlers(dotNetHelper: any): void {
    main.addEventListener('drop', (event: DragEvent) => {
        event.preventDefault();

        const symbolId = event.dataTransfer.getData("text");

        if (symbolId === '') {
            return;
        }

        const rect = main.getBoundingClientRect();

        // Calculate the mouse position relative to the element
        const x = event.clientX - rect.left;
        const y = event.clientY - rect.top;

        dotNetHelper.invokeMethodAsync('AddSymbol', symbolId, x, y);
    });
}

export function getMouseX(clientX: number): number {
    const rect = main.getBoundingClientRect();
    return clientX - rect.left;
}

export function getMouseY(clientY: number): number {
    const rect = main.getBoundingClientRect();
    return clientY - rect.top;
}

export function connect(start: HTMLElement, end: HTMLElement): void {
    var line = new LeaderLine(start, end);
    line.color = '#e8eaed';
    // line.position();
}