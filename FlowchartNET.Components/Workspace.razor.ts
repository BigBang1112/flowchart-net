declare const LeaderLine: any;

const lineSize = 4;

let currentLine: any;

const main = document.getElementById("workspace");

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

        dotNetHelper.invokeMethodAsync('AddSymbolAsync', symbolId, x, y);
    });

    main.addEventListener('mousemove', (e) => {
        if (currentLine) {
            currentLine.show();
            currentLine.setOptions({
                end: LeaderLine.pointAnchor(document.body, { x: e.clientX, y: e.clientY })
            });
        }
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

export function startLine(start: HTMLElement, startSocket: string, zoom: number): void {
    if (currentLine) {
        currentLine.remove();
    }

    var line = new LeaderLine(start, LeaderLine.pointAnchor(document.body, { x: 0, y: 0 }), {
        color: '#e8eaed',
        startSocket: startSocket,
        path: 'grid',
        hide: true,
        size: lineSize * zoom,
        dash: { animation: true }
    });

    currentLine = line;
}

export function endLine(end: HTMLElement, endSocket: string): any {
    if (!currentLine) {
        return null;
    }

    const line = currentLine;
    currentLine = null;

    line.show();
    line.setOptions({
        end: end,
        endSocket: endSocket,
        dash: false
    });

    return line;
}

export function createFullLine(start: HTMLElement, end: HTMLElement, startSocket: string, endSocket: string, zoom: number): any {
    const line = new LeaderLine(start, end, {
        color: '#e8eaed',
        startSocket: startSocket,
        endSocket: endSocket,
        path: 'grid',
        size: lineSize * zoom
    });
    return line;
}


export function removeCurrentLine(): void {
    if (currentLine) {
        currentLine.remove();
        currentLine = null;
    }
}

export function updateLine(line: any, zoom: number): void {
    line.size = lineSize * zoom;
    line.position();
}

export function simulateLine(line: any, stepTime: number): any {
    const simulationLine = new LeaderLine(line.start, line.end, {
        color: '#ffff00',
        size: line.size,
        path: line.path,
        hide: true,
        startSocket: line.startSocket,
        endSocket: line.endSocket
    });
    simulationLine.show('draw', { duration: stepTime, timing: 'ease' });
    return simulationLine;
}
