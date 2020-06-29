export class GridModel {

  public fields: { key: string, name: string }[];

  public values: any[];

}

export enum GridActionsType {
  none, onlyView, onlyEdit, both
}
