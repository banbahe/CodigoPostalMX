const ctrlScore = require('../controllers/score.controller')
module.exports = function (app) {
    app.post('/api/scores', ctrlScore.Create);
    app.get('/api/scores', ctrlScore.GetAll);
    app.get('/api/scores/:scoreid', ctrlScore.Get);
    app.delete('/api/scores/:scoreid', ctrlScore.Delete);
    app.patch('/api/scores/:scoreid', ctrlScore.Update);
};