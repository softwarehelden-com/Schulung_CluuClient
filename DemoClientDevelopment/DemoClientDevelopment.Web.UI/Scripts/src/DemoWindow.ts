import { DefaultCluuWindow, IDefaultCluuWindowOptions } from "cluu";


export interface IDemoWindowOptions extends IDefaultCluuWindowOptions {
    myDemoProperty?: unknown;
}

export class DemoWindow extends DefaultCluuWindow { 
    constructor(options?: IDemoWindowOptions) {
        super(options);
    }

    /**
     * @inheritdoc
     */
    protected override getDefaultOptions(): IDemoWindowOptions {
        return {
            ...super.getDefaultOptions(),
            myDemoProperty: null
        };
    }

    /**
     * Creates the control structure and initializes the properties.
     * The utilized JQuery object needs to be created and initialized in this method.
     * While in this method, Property-Changed events are disabled.
     */
    protected override initialize(options: IDemoWindowOptions): void {
        super.initialize(options);

        // Setting properties at the end of initialization, when the control structure exists.
        this._myDemoProperty = options.myDemoProperty;
    }

    private _myDemoProperty: unknown;

    public get myDemoProperty() {
        return this._myDemoProperty;
    }

    public set myDemoProperty(myDemoProperty: unknown) {
        this._myDemoProperty = myDemoProperty;
    }
}
