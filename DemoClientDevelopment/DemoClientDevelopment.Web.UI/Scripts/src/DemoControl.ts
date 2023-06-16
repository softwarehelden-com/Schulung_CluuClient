import { CluuContainer, CluuControl, ICluuControlOptions } from "cluu";

/**
 * Options for the DemoControl control.
 */
export interface IDemoControlOptions extends ICluuControlOptions {
    myDemoProperty?: unknown;
}

/**
 * DemoControl
 */
export class DemoControl extends CluuControl {
    private container: CluuContainer;

    constructor(options?: IDemoControlOptions) {
        super(options);
    }

    /**
     * @inheritdoc
     */
    protected override getDefaultOptions(): IDemoControlOptions{
        return {
            ...super.getDefaultOptions(),
            myDemoProperty: 1
        };
    }

    /**
     * Creates the control structure and initializes the properties.
     * The utilized JQuery object needs to be created and initialized in this method.
     * While in this method, Property-Changed events are disabled.
     */
    protected initialize(options: IDemoControlOptions): void {
        this.registerProperty("myDemoProperty", this.synchronizeMyDemoProperty);

        // Setting up the control structure (i.e. all elements used).
        // Instance should be created with imported variable (CluuControls).
        this.container = new CluuContainer({
            class: "demoClientDevelopment-controls-demoControl"
        });

        // Setting properties at the end of initialization, when the control structure exists.
        this._myDemoProperty = options.myDemoProperty;
    }

    public toJQuery(): JQuery {
        return this.container.toJQuery();
    }

    private _myDemoProperty: unknown;
    
    public get myDemoProperty() {
        return this._myDemoProperty;
    }

    public set myDemoProperty(myDemoProperty: unknown){
        this._myDemoProperty = myDemoProperty;
    }

    /**
     * Synchronizes the myDemoProperty with the UI.
     */
    private synchronizeMyDemoProperty(): void {

        // Synchronize the demo property with the UI here.
    }
}
