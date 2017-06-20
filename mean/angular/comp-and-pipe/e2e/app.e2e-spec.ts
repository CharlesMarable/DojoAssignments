import { CompAndPipePage } from './app.po';

describe('comp-and-pipe App', () => {
  let page: CompAndPipePage;

  beforeEach(() => {
    page = new CompAndPipePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
