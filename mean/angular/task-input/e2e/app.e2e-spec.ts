import { TaskInputPage } from './app.po';

describe('task-input App', () => {
  let page: TaskInputPage;

  beforeEach(() => {
    page = new TaskInputPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
